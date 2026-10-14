import { DateRange, Delete, Wallet } from "@mui/icons-material";
import { Box, Button, List, Typography } from "@mui/material";
import type { Expense } from "../lib/types";
import { useExpenses } from "../lib/hooks/useExpenses";

export default function ExpenseWindow() {
  const { expenses, pendingExpenses, deleteExpense } = useExpenses();

  return (
    <List>
      {pendingExpenses ? <Typography>Expenses are pending</Typography>
        : expenses!.map((expense: Expense) => (
          <Box key={expense.id}
            sx={{
              borderRadius: 5, width: "100%", backgroundColor: "background.paper", p: 3, border: 2,
              borderColor: "divider", mt: 1, px: 5,
            }} >
            <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center", }}>
              <Box>
                <Box sx={{ display: "flex", alignItems: "center", gap: 1, pb: 1 }}>
                  <Wallet />
                  <Typography variant="h4" color="text">{expense.name} </Typography>
                </Box>
                <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                  <Typography color="text"> {expense.description} </Typography>
                  <Typography color="text"> {expense.id} </Typography>
                  <DateRange />
                  <Typography color="text"> {new Date(expense.date).toLocaleDateString("en-US", {
                    month: "short",
                    day: "numeric",
                  })} </Typography>
                </Box>
              </Box>

              <Box sx={{ display: "flex", alignItems: "center", gap: 3}}>
                <Typography variant="h4" color="text"> -€{expense.amount.toFixed(2)} </Typography>
                <Button variant='outlined' onClick={() => deleteExpense.mutate(expense.id)}
                  disabled={deleteExpense.isPending}><Delete /></Button>
              </Box>

            </Box>
          </Box>
        ))
      }
    </List>

  );
}