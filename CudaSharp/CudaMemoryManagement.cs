using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CudaSharp
{
    public unsafe class CudaMemoryManagement
    {
        private CudaSharpStream stream;

        public CudaMemoryManagement(CudaSharpStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            this.stream = stream;
        }

        public void Copy(CudaHostVector hostVector, CudaDeviceVector deviceVector)
        {
            if (hostVector == null)
            {
                throw new ArgumentNullException("hostVector");
            }
            if (deviceVector == null)
            {
                throw new ArgumentNullException("deviceVector");
            }
            if (hostVector.Length != deviceVector.Length)
            {
                throw new ArgumentException("Vector lengths should be equal.");
            }

            CudaMemoryImports.CudaSetVector(hostVector.Length, sizeof(float), hostVector.PageLockedPointer, hostVector.ElementSpacing,
                deviceVector.DevicePointer, deviceVector.ElementSpacing, this.stream.StreamId.Value);
        }

        public void Copy(CudaDeviceVector deviceVector, CudaHostVector hostVector)
        {
            if (hostVector == null)
            {
                throw new ArgumentNullException("hostVector");
            }
            if (deviceVector == null)
            {
                throw new ArgumentNullException("deviceVector");
            }
            if (hostVector.Length != deviceVector.Length)
            {
                throw new ArgumentException("Vector lengths should be equal.");
            }

            CudaMemoryImports.CudaGetVector(hostVector.Length, sizeof(float), deviceVector.DevicePointer, deviceVector.ElementSpacing,
                hostVector.PageLockedPointer, hostVector.ElementSpacing, this.stream.StreamId.Value);
        }
    }
}
