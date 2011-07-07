using System.Runtime.InteropServices;

namespace CudaSharp
{
    unsafe static class CudaMemoryImports
    {
        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* CudaHostMalloc(int sizeInBytes);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* CudaDeviceMalloc(int sizeInBytes);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CudaHostFree(void* p);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CudaDeviceFree(void* p);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CudaSetVector(int n, int elemSize, void* hostPointer, int incX, void* devicePointer,
            int incY, void* streamId);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CudaGetVector(int n, int elemSize, void* devicePointer, int incX, void* hostPointer,
            int incY, void* streamId);
    }
}
