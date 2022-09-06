function reduce<TInput, TOutput>(
  array: TInput[],
  reducerFn: (acc: TOutput, currentValue: TInput, currentIndex: number) => TOutput,
  initialValue: TOutput
): TOutput {
}

export { reduce };
