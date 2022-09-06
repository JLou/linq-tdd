function reduce<TInput, TOutput>(
  array: TInput[],
  reducerFn: (acc: TOutput, currentValue: TInput, currentIndex: number) => TOutput,
  initialValue: TOutput
): TOutput {
  let output = initialValue;
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    output = reducerFn(output, element, index);
  }
  
  return output;
}

export { reduce };
