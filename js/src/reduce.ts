function reduce<T, U>(
  array: T[],
  reducerFn: (acc: U, currentValue: T, currentIndex: number) => U,
  initialValue: U
): U {
  return initialValue;
}

export { reduce };
