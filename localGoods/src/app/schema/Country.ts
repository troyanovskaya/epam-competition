interface Country{
  id:string,
  name:string,
  cities:{id:string, name:string, countryId:string}[]}
export {Country}
