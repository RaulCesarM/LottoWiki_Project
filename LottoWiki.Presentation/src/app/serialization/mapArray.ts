import { OperatorFunction } from "rxjs";
import { Class } from "./class";

export declare function mapArray<T>(type: Class<T>): OperatorFunction<object, T[]>;