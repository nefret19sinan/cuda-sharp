using System.Runtime.InteropServices;

namespace CudaSharp
{
    unsafe struct CurandGenerator
    {
        public void* Value { get; set; }
    }

    unsafe static class CudaRandomImports
    {
        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* CreateCurandGenerator(void* streamId);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyCurandGenerator(void* generator);

        [DllImport("CudaExports.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CurandGenerateUniform(void* generator, float* devicePointer, int length);
    }
}
