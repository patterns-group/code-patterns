#region FreeBSD

// Copyright (c) 2014, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that
// the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the
//    following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the
//    following disclaimer in the documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

using AutoMapper;

namespace Patterns.Mapping
{
  /// <summary>
  ///   Aggregates central AutoMapper services.
  /// </summary>
  public interface IMappingServices
  {
    /// <summary>
    ///   Gets the engine.
    /// </summary>
    /// <value>
    ///   The engine.
    /// </value>
    IMappingEngine Engine { get; }

    /// <summary>
    ///   Gets the configuration.
    /// </summary>
    /// <value>
    ///   The configuration.
    /// </value>
    IConfiguration Configuration { get; }

    /// <summary>
    ///   Gets the configuration provider.
    /// </summary>
    /// <value>
    ///   The configuration provider.
    /// </value>
    IConfigurationProvider ConfigurationProvider { get; }

    /// <summary>
    ///   Maps the specified source to the indicated destination.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    TDestination Map<TSource, TDestination>(TSource source);

    /// <summary>
    ///   Maps the specified source to the indicated destination.
    /// </summary>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    TDestination Map<TDestination>(object source);

    /// <summary>
    ///   Maps the specified source to the indicated destination.
    /// </summary>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="opts">The opts.</param>
    /// <returns></returns>
    TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts);

    /// <summary>
    ///   Maps the specified source to the indicated destination.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="opts">The opts.</param>
    /// <returns></returns>
    TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions> opts);

    /// <summary>
    ///   Maps the specified source to the specified destination.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <returns></returns>
    TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

    /// <summary>
    ///   Maps the specified source to the specified destination.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <param name="opts">The opts.</param>
    /// <returns></returns>
    TDestination Map<TSource, TDestination>(TSource source, TDestination destination,
      Action<IMappingOperationOptions> opts);

    /// <summary>
    ///   Maps the specified source to the indicated destination.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="sourceType">Type of the source.</param>
    /// <param name="destinationType">Type of the destination.</param>
    /// <returns></returns>
    object Map(object source, Type sourceType, Type destinationType);

    /// <summary>
    ///   Maps the specified source to the indicated destination.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="sourceType">Type of the source.</param>
    /// <param name="destinationType">Type of the destination.</param>
    /// <param name="opts">The opts.</param>
    /// <returns></returns>
    object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts);

    /// <summary>
    ///   Maps the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <param name="sourceType">Type of the source.</param>
    /// <param name="destinationType">Type of the destination.</param>
    /// <returns></returns>
    object Map(object source, object destination, Type sourceType, Type destinationType);

    /// <summary>
    ///   Maps the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <param name="sourceType">Type of the source.</param>
    /// <param name="destinationType">Type of the destination.</param>
    /// <param name="opts">The opts.</param>
    /// <returns></returns>
    object Map(object source, object destination, Type sourceType, Type destinationType,
      Action<IMappingOperationOptions> opts);
  }
}