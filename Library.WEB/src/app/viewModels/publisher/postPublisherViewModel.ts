import { GetBookViewItem } from '../book/getBookViewItem';

export class PostPublisherViewModel {
    id: number
    name: string
    address: string
    books: Array<GetBookViewItem>
}
