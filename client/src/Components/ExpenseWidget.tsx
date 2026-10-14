import { Box } from '@mui/material';
import { useExpenses } from '../lib/hooks/useExpenses';
import ExpenseCard from './ExpenseCard';

export default function ExpenseWidget() {
    const { averageExpense, pendingAverage, averageError,
        transactions, pendingTransactions, transactionsError,
        total, totalError, totalPending
     } = useExpenses();

  return (
    <Box sx={{ display: 'flex', flexDirection: 'row', gap: 1}}>
          <ExpenseCard title={"All-time Average"} value={"-€" + averageExpense?.toFixed(2)} isPending={pendingAverage} isError={averageError}/>
          <ExpenseCard title={"Total Spent"} value={"-€" + total?.toFixed(2)} isPending={totalPending} isError={totalError}/>
          <ExpenseCard title={"Transactions"} value={transactions?.toString()} isPending={pendingTransactions} isError={transactionsError}/>
        </Box>
  )
}