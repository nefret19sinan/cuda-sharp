#ifndef CUDA_RANDOM_CUH
#define CUDA_RANDOM_CUH

#include "kernel.cuh"
#include "curand.h"

extern "C"
{
	__declspec(dllexport) void* CreateCurandGenerator(void* streamId) throw(int);
	__declspec(dllexport) void DestroyCurandGenerator(void* generator) throw(int);
	__declspec(dllexport) void CurandGenerateUniform(void* generator, float* devicePointer, int length) throw(int);
}

#endif