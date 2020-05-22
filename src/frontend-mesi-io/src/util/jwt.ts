export function decode(jwt: string): any | null {
  const splits = jwt.split(".");
  if (splits.length !== 3) return null;

  const decoded = atob(splits[1]);
  return JSON.parse(decoded);
}
