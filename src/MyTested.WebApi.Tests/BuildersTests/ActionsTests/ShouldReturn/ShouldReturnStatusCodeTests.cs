﻿// MyTested.WebApi - ASP.NET Web API Fluent Testing Framework
// Copyright (C) 2015 Ivaylo Kenov.
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
namespace MyTested.WebApi.Tests.BuildersTests.ActionsTests.ShouldReturn
{
    using System.Net;
    using Exceptions;
    using NUnit.Framework;
    using Setups.Controllers;

    [TestFixture]
    public class ShouldReturnStatusCodeTests
    {
        [Test]
        public void ShouldReturnStatusCodeShouldNotThrowExceptionWhenActionReturnsStatusCode()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.StatusCodeAction())
                .ShouldReturn()
                .StatusCode();
        }

        [Test]
        [ExpectedException(
            typeof(HttpActionResultAssertionException),
            ExpectedMessage = "When calling BadRequestAction action in WebApiController expected action result to be StatusCodeResult, but instead received BadRequestResult.")]
        public void ShouldReturnStatusCodeShouldThrowExceptionWhenActionDoesNotReturnStatusCode()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.BadRequestAction())
                .ShouldReturn()
                .StatusCode();
        }

        [Test]
        public void ShouldReturnStatusCodeShouldNotThrowExceptionWhenActionReturnsCorrectStatusCode()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.StatusCodeAction())
                .ShouldReturn()
                .StatusCode(HttpStatusCode.Found);
        }

        [Test]
        [ExpectedException(
            typeof(HttpStatusCodeResultAssertionException),
            ExpectedMessage = "When calling StatusCodeAction action in WebApiController expected to have 201 (Created) status code, but received 302 (Redirect).")]
        public void ShouldReturnStatusCodeShouldThrowExceptionWhenActionReturnsWrongStatusCode()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.StatusCodeAction())
                .ShouldReturn()
                .StatusCode(HttpStatusCode.Created);
        }

        [Test]
        [ExpectedException(
            typeof(HttpActionResultAssertionException),
            ExpectedMessage = "When calling BadRequestAction action in WebApiController expected action result to be StatusCodeResult, but instead received BadRequestResult.")]
        public void ShouldReturnStatusCodeShouldThrowExceptionWhenActionDoesNotReturnStatusCodeAndPassingStatusCode()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.BadRequestAction())
                .ShouldReturn()
                .StatusCode(HttpStatusCode.Created);
        }
    }
}
