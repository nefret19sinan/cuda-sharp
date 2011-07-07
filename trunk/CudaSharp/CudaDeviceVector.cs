using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CudaSharp
{
    public unsafe sealed class CudaDeviceVector : IDisposable
    {
        public int Length { get; private set; }
        public float* DevicePointer { get; private set; }
        public int ElementSpacing { get; private set; }

        private bool ownsMemoryAtPointer;

        public CudaDeviceVector(int length)
        {
            this.Length = length;
            this.ownsMemoryAtPointer = true;
            this.ElementSpacing = 1;
            this.DevicePointer = (float*)CudaMemoryImports.CudaDeviceMalloc(sizeof(float) * length);
        }

        public void Dispose()
        {
            if (this.ownsMemoryAtPointer)
            {
                CudaMemoryImports.CudaDeviceFree(this.DevicePointer);
            }
        }
    }
}
