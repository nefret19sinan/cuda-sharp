#ifndef CUDA_MEMORY_MANAGEMENT_CUH
#define CUDA_MEMORY_MANAGEMENT_CUH

#include "kernel.cuh"

#include "cublas_v2.h"

extern "C"
{
	__declspec(dllexport) void* CudaHostMalloc(int sizeInBytes) throw(int);
	__declspec(dllexport) void* CudaDeviceMalloc(int sizeInBytes) throw(int);
	__declspec(dllexport) void CudaHostFree(void* p) throw(int);
	__declspec(dllexport) void CudaDeviceFree(void* devPtr) throw(int);
	__declspec(dllexport) void CudaSetVector(int n, int elemSize, void* hostPointer, int incX, void* devicePointer, 
		int incY, void* streamId) throw(int);
	__declspec(dllexport) void CudaGetVector(int n, int elemSize, void* devicePointer, int incX, void* hostPointer,
		int incY, void* streamId) throw(int);
}

#endif