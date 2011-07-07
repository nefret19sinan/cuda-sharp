using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CudaSharp
{
    public unsafe sealed class CudaHostVector : IDisposable
    {
        public int Length { get; private set; }
        public float* PageLockedPointer { get; private set; }
        public int ElementSpacing { get; private set; }
        public ScalarCollection Scalars { get; private set; }

        private bool ownsMemoryAtPointer;

        public CudaHostVector(int length)
        {
            this.Length = length;
            this.ElementSpacing = 1;
            this.ownsMemoryAtPointer = true;
            this.PageLockedPointer = (float*)CudaMemoryImports.CudaHostMalloc(sizeof(float) * length);
            this.Scalars = new ScalarCollection(this);
        }

        public void Dispose()
        {
            if (this.ownsMemoryAtPointer)
            {
                CudaMemoryImports.CudaHostFree(this.PageLockedPointer);
            }
        }

        public float this[int elementIndex]
        {
            get
            {
                return this.PageLockedPointer[elementIndex*this.ElementSpacing];
            }
            set
            {
                this.PageLockedPointer[elementIndex*this.ElementSpacing] = value;
            }
        }
    }
}
