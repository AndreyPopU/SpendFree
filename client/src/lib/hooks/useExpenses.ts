import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import axios from "axios";
import type { CreateExpense, Expense } from "../types";

export const useExpenses = () => {
  const path = "https://localhost:5001/api/expenses/";
  const queryClient = useQueryClient();

  const { data: expenses, isPending: pendingExpenses, isError: expensesError } = useQuery({
    queryKey: ['expenses'],
    queryFn: async () => {
      const response = await axios.get<Expense[]>(path);
      return response.data;
    }
  });

  const { data: averageExpense, isPending: pendingAverage, isError: averageError } = useQuery({
    queryKey: ['averageExpense'],
    queryFn: async () => {
      const response = await axios.get<number>(`${path}average`);
      return response.data;
    }
  });

  const { data: transactions, isPending: pendingTransactions, isError: transactionsError } = useQuery({
    queryKey: ['transactions'],
    queryFn: async () => {
      const response = await axios.get<number>(`${path}transactions`);
      return response.data;
    }
  })

  const { data: total, isError: totalError, isPending: totalPending } = useQuery({
    queryKey: ['totalExpenses'],
    queryFn: async () => {
      const response = await axios.get<number>(`${path}total`);
      return response.data;
    },
  })

  const createExpense = useMutation({
    mutationFn: async (expense: CreateExpense) => {
      const response = await axios.post(path, expense);
      return response.data;
    }
  })

  const deleteExpense = useMutation({
    mutationFn: async (id: number) => {

      const response = await axios.delete(path + id);

      return response.data;
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries();
    }
  })

  return {
    expenses, pendingExpenses, expensesError,
    averageExpense, pendingAverage, averageError,
    transactions, pendingTransactions, transactionsError,
    total, totalError, totalPending,
    createExpense,
    deleteExpense
  }
}