using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CudaSharp
{
    public unsafe sealed class CudaRandom : IDisposable
    {
        private CudaSharpStream stream;
        private CurandGenerator generator;

        public CudaRandom(CudaSharpStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            this.stream = stream;

            this.generator.Value = CudaRandomImports.CreateCurandGenerator(stream.StreamId.Value);
        }

        public void GenerateUniform(CudaDeviceVector deviceVector)
        {
            if (deviceVector == null)
            {
                throw new ArgumentNullException("deviceVector");
            }
            CudaRandomImports.CurandGenerateUniform(this.generator.Value, deviceVector.DevicePointer, deviceVector.Length);
        }

        public void Dispose()
        {
            this.stream.Synchronize();

            CudaRandomImports.DestroyCurandGenerator(this.generator.Value);
        }
    }
}
