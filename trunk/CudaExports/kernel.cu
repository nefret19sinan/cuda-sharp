
#include "kernel.cuh"

void* CreateCudaStream() throw(int)
{
	cudaStream_t* streamId = (cudaStream_t*) malloc(sizeof(cudaStream_t));
	CUDA_SAFE_CALL(cudaStreamCreate(streamId));

	return (void*) streamId;
}

void DestroyCudaStream(void* streamId) throw(int)
{
	cudaStream_t* strId = (cudaStream_t*) streamId;

	CUDA_SAFE_CALL(cudaStreamDestroy(*strId));
	free(streamId);
}

void CudaStreamSync(void* streamId) throw(int)
{
	cudaStream_t* strId = (cudaStream_t*) streamId;

	CUDA_SAFE_CALL(cudaStreamSynchronize(*strId));
}