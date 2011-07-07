
#include "CudaAlgebra.cuh"

extern "C"
{
	void* CreateCublasHandle(void* streamId) throw(int)
	{
		cudaStream_t* strId = (cudaStream_t*) streamId;
		cublasHandle_t* chandle = (cublasHandle_t*) malloc(sizeof(cublasHandle_t));

		CUBLAS_SAFE_CALL(cublasCreate(chandle));
		CUBLAS_SAFE_CALL(cublasSetStream(*chandle, *strId));

		return (void*) chandle;
	}

	void DestroyCublasHandle(void* cublasHandle) throw(int)
	{
		cublasHandle_t* chandle = (cublasHandle_t*) cublasHandle;
	
		CUBLAS_SAFE_CALL(cublasDestroy(*chandle));
	
		free(cublasHandle);
	}

	void CublasScalarMult(void* cublasHandle, float* devicePointer, int elemSpacing, int length, float* scalar) throw(int)
	{
		cublasHandle_t* chandle = (cublasHandle_t*) cublasHandle;

		CUBLAS_SAFE_CALL(cublasSscal(*chandle, length, scalar, devicePointer, elemSpacing));
	}
}