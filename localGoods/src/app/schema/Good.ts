import { Category } from "./Category"

interface Good{
  id: string,
  name: string,
  description: string,
  price: number,
  poster: string,
  discount: 0,
  vendorId: string,
  amount: number,
  unitType: {
    id: string,
    name: string
  },
  categories: Category[],
  images: string[]
}

export {Good}

