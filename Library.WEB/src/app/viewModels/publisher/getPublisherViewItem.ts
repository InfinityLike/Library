import { GetBookViewItem } from '../book/getBookViewItem';

export class GetPublisherViewItem {
    id: number
    name: string
    address: string
    books: Array<GetBookViewItem>
}
