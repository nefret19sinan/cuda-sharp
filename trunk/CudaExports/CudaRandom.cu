
#include "CudaRandom.cuh"

void* CreateCurandGenerator(void* streamId) throw(int)
{
	curandGenerator_t* gen = (curandGenerator_t*) malloc(sizeof(curandGenerator_t));
	cudaStream_t* strId = (cudaStream_t*) streamId;

	CURAND_SAFE_CALL(curandCreateGenerator(gen, CURAND_RNG_PSEUDO_DEFAULT));
	CURAND_SAFE_CALL(curandSetStream(*gen, *strId));

	return (void*) gen;
}

void DestroyCurandGenerator(void* generator) throw(int)
{
	curandGenerator_t* gen = (curandGenerator_t*) generator;

	CURAND_SAFE_CALL(curandDestroyGenerator(*gen));

	free(generator);
}

void CurandGenerateUniform(void* generator, float* devicePointer, int length) throw(int)
{
	curandGenerator_t* gen = (curandGenerator_t*) generator;

	CURAND_SAFE_CALL(curandGenerateUniform(*gen, devicePointer, length));
}