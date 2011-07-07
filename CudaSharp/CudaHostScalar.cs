using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CudaSharp
{
    public unsafe sealed class CudaHostScalar : IDisposable
    {
        public float Value
        {
            get
            {
                return PageLockedPointer[0];
            }
            set
            {
                PageLockedPointer[0] = value;
            }
        }
        public float* PageLockedPointer { get; private set; }

        private bool ownsMemoryAtPointer;

        public CudaHostScalar(float scalar)
        {
            this.PageLockedPointer = (float*) CudaMemoryImports.CudaHostMalloc(sizeof(float));
            this.Value = scalar;
            this.ownsMemoryAtPointer = true;
        }

        public CudaHostScalar(float* pointer)
        {
            this.PageLockedPointer = pointer;
            this.ownsMemoryAtPointer = false;
        }

        public void Dispose()
        {
            if (this.ownsMemoryAtPointer)
            {
                CudaMemoryImports.CudaHostFree(this.PageLockedPointer);
            }
        }
    }

    public unsafe class ScalarCollection
    {
        readonly CudaHostVector that;

        public ScalarCollection(CudaHostVector that)
        {
            this.that = that;
        }

        public CudaHostScalar this[int elementIndex]
        {
            get
            {
                return new CudaHostScalar(&this.that.PageLockedPointer[elementIndex * this.that.ElementSpacing]);
            }
        }
    }
}
