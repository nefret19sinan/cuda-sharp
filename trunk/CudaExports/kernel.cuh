#ifndef KERNEL_CUH
#define KERNEL_CUH

#include "cuda_runtime.h"
#include <stdlib.h>

#define CUDA_SAFE_CALL(P) if ((P) != cudaSuccess) throw 1
#define CUBLAS_SAFE_CALL(P) if ((P) != CUBLAS_STATUS_SUCCESS) throw 1
#define CURAND_SAFE_CALL(P) if ((P) != CURAND_STATUS_SUCCESS) throw 1

extern "C"
{
	__declspec(dllexport) void* CreateCudaStream() throw(int);
	__declspec(dllexport) void DestroyCudaStream(void* streamId) throw(int);
	__declspec(dllexport) void CudaStreamSync(void* streamId) throw(int);
}

#endif