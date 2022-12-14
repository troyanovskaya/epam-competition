import { Category } from "./category.model"

export interface Good{
  id: string,
  name: string,
  description: string,
  price: number,
  poster: string,
  discount: number,
  vendorId: string,
  amount: number,
  unitType: {
    id: string,
    name: string
  },
  categories: Category[],
  images: string[]
}


