#ifndef CUDA_ALGEBRA_CUH
#define CUDA_ALGEBRA_CUH

#include "kernel.cuh"

#include "cublas_v2.h"


extern "C"
{
	__declspec(dllexport) void* CreateCublasHandle(void* streamId) throw(int);
	__declspec(dllexport) void DestroyCublasHandle(void* cublasHandle) throw(int);
	__declspec(dllexport) void CublasScalarMult(void* cublasHandle, float* devicePointer, int elemSpacing, int length, 
		float* scalar) throw(int);
}

#endif