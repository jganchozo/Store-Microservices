using AutoMapper;
using GenFu;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Store.Api.Book.Application;
using Store.Api.Book.Model;
using Store.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Store.Api.Book.Tests
{
    public class BookServiceTest
    {
        private IEnumerable<BookModel> GetFakeData()
        {
            A.Configure<BookModel>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.BookModelId, () => Guid.NewGuid());

            var list = A.ListOf<BookModel>(30);
            list[0].BookModelId = Guid.Empty;

            return list;
        }

        private Mock<BookContext> CreateContext()
        {
            var testData = GetFakeData().AsQueryable();
            var dbSet = new Mock<DbSet<BookModel>>();

            dbSet.As<IQueryable<BookModel>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<BookModel>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<BookModel>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<BookModel>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<BookModel>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<BookModel>(testData.GetEnumerator()));

            dbSet.As<IQueryable<BookModel>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<BookModel>(testData.Provider));

            Mock<BookContext> context = new Mock<BookContext>();
            context.Setup(x => x.Book).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetBooks()
        {
            //System.Diagnostics.Debugger.Launch();

            Mock<BookContext> mockContext = CreateContext();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingTest());
            });

            var mapper = mapperConfig.CreateMapper();

            SelectBookCommand.Handler handler = new SelectBookCommand.Handler(mockContext.Object, mapper);
            SelectBookCommand.Execute request = new SelectBookCommand.Execute();
            var list = await handler.Handle(request, new CancellationToken());

            Assert.True(list.Any());
        }

        [Fact]
        public async void GetBookById()
        {
            //System.Diagnostics.Debugger.Launch();

            Mock<BookContext> mockContext = CreateContext();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingTest());
            });

            var mapper = mapperConfig.CreateMapper();

            SelectBookByIdCommand.Execute request = new SelectBookByIdCommand.Execute()
            {
                BookModelId = Guid.Empty
            };

            SelectBookByIdCommand.Handler handler = new SelectBookByIdCommand.Handler(mockContext.Object, mapper);
            var book = await handler.Handle(request, new CancellationToken());

            Assert.NotNull(book);
            Assert.True(book.BookModelId == Guid.Empty);
        }

        [Fact]
        public async void SaveBook()
        {
            //System.Diagnostics.Debugger.Launch();

            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "BookDB")
                .Options;

            var context = new BookContext(options);

            CreateBookCommand.Execute request = new CreateBookCommand.Execute()
            {
                Title = "Microservices with c#",
                AuthorGuid = Guid.Empty,
                PublicationDate = DateTime.Now
            };

            CreateBookCommand.Handler handler = new CreateBookCommand.Handler(context);

            Unit result = await handler.Handle(request, new CancellationToken());

            Assert.True(result != null);
        }
    }
}
