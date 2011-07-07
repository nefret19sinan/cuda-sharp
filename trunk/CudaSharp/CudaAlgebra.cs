using System;

namespace CudaSharp
{
    public unsafe sealed class CudaAlgebra : IDisposable
    {
        private CudaSharpStream stream;
        private CublasHandle handle;

        public CudaAlgebra(CudaSharpStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            this.stream = stream;

            this.handle.Value = CudaAlgebraImports.CreateCublasHandle(stream.StreamId.Value);
        }

        public void ScalarMultiplication(CudaDeviceVector deviceVector, CudaHostScalar scalar)
        {
            if (deviceVector == null)
            {
                throw new ArgumentNullException("deviceVector");
            }
            if (scalar == null)
            {
                throw new ArgumentNullException("scalar");
            }
            CudaAlgebraImports.CublasScalarMult(this.handle.Value, deviceVector.DevicePointer, deviceVector.ElementSpacing,
                deviceVector.Length, scalar.PageLockedPointer);
        }

        public void Dispose()
        {
            this.stream.Synchronize();

            CudaAlgebraImports.DestroyCublasHandle(this.handle.Value);
        }
    }
}
