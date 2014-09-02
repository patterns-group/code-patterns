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
using System.Collections.Generic;

using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Core.Resolving;

namespace Patterns.Autofac.Core
{
  public class AccessibleContainer : IContainer
  {
    protected readonly IContainer Container;

    public AccessibleContainer() : this(new ContainerBuilder().Build())
    {
    }

    public AccessibleContainer(IContainer container)
    {
      Container = container;
    }

    public virtual object Tag
    {
      get { return Container.Tag; }
    }

    public virtual IComponentRegistry ComponentRegistry
    {
      get { return Container.ComponentRegistry; }
    }

    public virtual ILifetimeScope BeginLifetimeScope()
    {
      return Container.BeginLifetimeScope();
    }

    public virtual IDisposer Disposer
    {
      get { return Container.Disposer; }
    }

    public virtual object ResolveComponent(IComponentRegistration registration, IEnumerable<Parameter> parameters)
    {
      return Container.ResolveComponent(registration, parameters);
    }

    public virtual event EventHandler<LifetimeScopeBeginningEventArgs> ChildLifetimeScopeBeginning
    {
      add { Container.ChildLifetimeScopeBeginning += value; }
      remove { Container.ChildLifetimeScopeBeginning -= value; }
    }

    public virtual event EventHandler<LifetimeScopeEndingEventArgs> CurrentScopeEnding
    {
      add { Container.CurrentScopeEnding += value; }
      remove { Container.CurrentScopeEnding -= value; }
    }

    public virtual event EventHandler<ResolveOperationBeginningEventArgs> ResolveOperationBeginning
    {
      add { Container.ResolveOperationBeginning += value; }
      remove { Container.ResolveOperationBeginning -= value; }
    }

    public virtual ILifetimeScope BeginLifetimeScope(object tag, Action<ContainerBuilder> configurationAction)
    {
      return Container.BeginLifetimeScope(tag, configurationAction);
    }

    public virtual ILifetimeScope BeginLifetimeScope(Action<ContainerBuilder> configurationAction)
    {
      return Container.BeginLifetimeScope(configurationAction);
    }

    public virtual ILifetimeScope BeginLifetimeScope(object tag)
    {
      return Container.BeginLifetimeScope(tag);
    }

    public virtual void Dispose()
    {
      var disposableContainer = Container as IDisposable;
      if (disposableContainer != null) disposableContainer.Dispose();
    }
  }
}