
#include "CudaMemoryManagement.cuh"


void* CudaHostMalloc(int sizeInBytes) throw(int)
{
	void* p;
	CUDA_SAFE_CALL(cudaHostAlloc((void**) &p, sizeInBytes, cudaHostAllocPortable));

	return p;
}

void* CudaDeviceMalloc(int sizeInBytes) throw(int)
{
	void* p;
	CUDA_SAFE_CALL(cudaMalloc((void**) &p, sizeInBytes));

	return p;
}

void CudaHostFree(void* p) throw(int)
{
	CUDA_SAFE_CALL(cudaFreeHost(p));
}

void CudaDeviceFree(void* devPtr) throw(int)
{
	CUDA_SAFE_CALL(cudaFree(devPtr));
}

void CudaSetVector(int n, int elemSize, void* hostPointer, int incX, void* devicePointer, 
	int incY, void* streamId) throw(int)
{
	cudaStream_t* str = (cudaStream_t*) streamId;
	
	CUBLAS_SAFE_CALL(cublasSetVectorAsync(n, elemSize, hostPointer, incX, devicePointer, incY, *str));
}

void CudaGetVector(int n, int elemSize, void* devicePointer, int incX, void* hostPointer,
	int incY, void* streamId) throw(int)
{
	cudaStream_t* str = (cudaStream_t*) streamId;

	CUBLAS_SAFE_CALL(cublasGetVectorAsync(n, elemSize, devicePointer, incX, hostPointer, incY, *str));
}