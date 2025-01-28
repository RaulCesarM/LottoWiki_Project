import { OperatorFunction, map } from 'rxjs';
import { Class } from './class';

export function mapObject<T extends object>(type: Class<T>): OperatorFunction<object, T> {
    return map((input: object) => Object.assign(new type(), input));
}
