﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2017 Simplesoft.pt
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using Microsoft.Extensions.Logging;

namespace SimpleSoft.Mediator
{
    /// <summary>
    /// Logging extensions
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// Enables logging for a given <see cref="IMediator"/>.
        /// </summary>
        /// <param name="mediator">The mediator to wrap</param>
        /// <param name="logger">The logger to use</param>
        /// <returns>Mediator wrapper</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IMediator UsingLogger(this IMediator mediator, ILogger<IMediator> logger)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            return new LoggingMediator(mediator, logger);
        }

        /// <summary>
        /// Enables logging for a given <see cref="IMediatorFactory"/>.
        /// </summary>
        /// <param name="mediator">The mediator to wrap</param>
        /// <param name="logger">The logger to use</param>
        /// <returns>Mediator wrapper</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IMediatorFactory UsingLogger(this IMediatorFactory mediator, ILogger<IMediatorFactory> logger)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            return new LoggingMediatorFactory(mediator, logger);
        }

        internal static readonly object[] EmptyObjectArray = new object[0];

        internal static void LogDebug(this ILogger logger, string message)
        {
            logger.LogDebug(message, EmptyObjectArray);
        }
    }
}
