import { Category } from "./category.model"
import { UnitType } from "./unitType.model"

export interface Good{
  id: string,
  name: string,
  description: string,
  price: number,
  poster: string,
  discount: number,
  vendorId: string,
  amount: number,
  unitType: UnitType,
  categories: Category[],
  images: string[]
}


