using System.Runtime.InteropServices;

namespace CudaSharp
{
    unsafe struct CublasHandle
    {
        public void* Value { get; set; }
    }

    unsafe static class CudaAlgebraImports
    {
        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* CreateCublasHandle(void* streamId);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyCublasHandle(void* cublasHandle);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CublasScalarMult(void* cublasHandle, float* devicePointer, int elemSpacing,
            int length, float* scalar);
    }
}
