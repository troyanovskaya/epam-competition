import { Good } from "./good.model";

export interface Vendor{
    id:string,
    name : string,
    viberNumber: string,
    telegramName: string,
    instagramName: string,
    userId: string,
    products: Good,
    paymentMethods: object[],
    deliveryMethods: object[]
}