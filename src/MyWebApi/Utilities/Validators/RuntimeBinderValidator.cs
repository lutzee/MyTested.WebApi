﻿namespace MyWebApi.Utilities.Validators
{
    using System;
    using Exceptions;
    using Microsoft.CSharp.RuntimeBinder;

    /// <summary>
    /// Validator class containing dynamic action result calls validation logic.
    /// </summary>
    public static class RuntimeBinderValidator
    {
        /// <summary>
        /// Validates action call for RuntimeBinderException.
        /// </summary>
        /// <param name="action">Action to validate.</param>
        public static void ValidateBinding(Action action)
        {
            try
            {
                action();
            }
            catch (RuntimeBinderException ex)
            {
                var fullPropertyName = ex.Message.Split('\'')[3];
                throw new ActionCallAssertionException(string.Format(
                    "Expected action result to contain a '{0}' property to test, but in fact such property was not found.",
                    fullPropertyName));
            }
        }
    }
}