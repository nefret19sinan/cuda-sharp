Simple C# wrapper for NVIDIA CUDA Toolkit 4.0.

There is an unmanaged C++ DLL that exports the CUDA functionality to the actual CudaSharp library.

All operations are done through CudaSharpStream objects. All operations are asynchronous. Whenever you need the actual result back from the stream call CudaSharpStream.Synchronize().

Requires NVIDIA CUDA Toolkit 4.0 installed. You can get it at http://developer.nvidia.com/cuda-toolkit-40 .
Also, of course, you need a CUDA enabled GPU.