import {Travel} from './travel.model'

export class CalculateResulte{
 id:number;
  TravelToCon: Array<Travel>;
  isFreeDay:boolean;
  contractName: string;
  contractID:number;
  price:number
  CalculateResulte( travelToCon:Array<Travel>,  isFreeDay:boolean, contractName:string,contractID:number,price:number)
  {
      this.TravelToCon = travelToCon;
      this.isFreeDay = isFreeDay;
      this.contractID = contractID;
      this.price = price;
      this.contractName = contractName;
  }
}