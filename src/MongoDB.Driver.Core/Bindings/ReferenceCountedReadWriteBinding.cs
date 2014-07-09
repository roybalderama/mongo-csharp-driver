﻿/* Copyright 2013-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDB.Driver.Core.Bindings
{
    public class ReferenceCountedReadWriteBinding : ReferenceCountedReadBinding, IReadWriteBinding
    {
        // fields
        private readonly IReadWriteBinding _wrapped;

        // constructors
        public ReferenceCountedReadWriteBinding(IReadWriteBinding wrapped)
            : base(wrapped)
        {
            _wrapped = wrapped;
        }

        // methods
        IWriteBinding IWriteBinding.Fork()
        {
            throw new NotImplementedException(); // implemented by the handle
        }

        public new IReadWriteBinding Fork()
        {
            throw new NotImplementedException(); // implemented by the handle
        }

        public virtual Task<IConnectionSource> GetWriteConnectionSourceAsync(TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            ThrowIfDisposed();
            return _wrapped.GetWriteConnectionSourceAsync(timeout, cancellationToken);
        }

    }
}