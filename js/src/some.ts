function some<T>(array: T[], predicate: (T) => boolean): boolean {
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    if (predicate(element)) {
      return true;
    }
  }
  return false;
}

export { some };
