export interface Activity {
    id: string
    title: string
    date: string
    description: string
    category: string
    isCancelled: boolean
    city: string
    venue: string
    latitude: number
    longitude: number
}

export interface Expense {
  id: number;
  name: string;
  description: string;
  amount: number;
  date: string;
  categoryId: number;
  categoryName: string;
}

export interface CreateExpense {
  title: string;
  description: string;
  amount: number;
  categoryId: number;
}