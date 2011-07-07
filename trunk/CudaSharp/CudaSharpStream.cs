using System;

namespace CudaSharp
{
    public unsafe sealed class CudaSharpStream : IDisposable
    {
        private CudaStreamId streamId;
        public CudaStreamId StreamId
        {
            get
            {
                return streamId;
            }
        }
        public CudaMemoryManagement MemoryManagement { get; private set; }
        private CudaRandom random;
        public CudaRandom Random
        { 
            get
            {
                if (random == null)
                {
                    random = new CudaRandom(this);
                }
                return random;
            }
        }
        private CudaAlgebra algebra;
        public CudaAlgebra Algebra
        {
            get
            {
                if (algebra == null)
                {
                    algebra = new CudaAlgebra(this);
                }
                return algebra;
            }
        }

        public void Synchronize()
        {
            CudaImports.CudaStreamSync(this.streamId.Value);
        }

        public CudaSharpStream()
        {
            this.streamId.Value = CudaImports.CreateCudaStream();
            this.MemoryManagement = new CudaMemoryManagement(this);
        }

        public void Dispose()
        {
            this.Synchronize();
            if (this.random != null)
            {
                this.random.Dispose();
            }
            if (this.algebra != null)
            {
                this.algebra.Dispose();
            }
            CudaImports.DestroyCudaStream(this.streamId.Value);
        }
    }
}
