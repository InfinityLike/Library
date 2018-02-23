import { BookViewModel } from './bookViewModel';

export class PublisherViewModel {
    id: number
    name: string
    address: string
    books: Array<BookViewModel>
}
