using System.Runtime.InteropServices;

namespace CudaSharp
{
    public unsafe struct CudaStreamId
    {
        public void* Value { get; set; }
    }

    unsafe static class CudaImports
    {
        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* CreateCudaStream();

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyCudaStream(void* streamId);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CudaStreamSync(void* streamId);
    }
}
