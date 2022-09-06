function forEach<T>(
  array: T[],
  callbackfn: (value: T, index: number) => void
): void {
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    callbackfn(element, index);
  }
}

export { forEach };
