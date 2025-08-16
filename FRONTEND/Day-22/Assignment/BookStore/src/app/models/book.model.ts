export interface Book {
  id: number;
  title: string;
  price: number;
  publicationDate: string; // ISO string e.g. "2023-07-10"
  description: string;
  discountPercent?: number; // optional, e.g. 10 for 10%
}
