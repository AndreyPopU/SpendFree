
import { useState } from "react";
import { Button, MenuItem, Paper, TextField, Typography, Box } from "@mui/material";
import { useExpenses } from "../../lib/hooks/useExpenses";

export default function CreateExpense() {
  const { createExpense } = useExpenses();

  const [title, setTitle] = useState("");
  const [categoryId, setCategoryId] = useState("");
  const [description, setDescription] = useState("");
  const [amount, setAmount] = useState("");

  const handleSubmit = (event: React.SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();

    createExpense.mutate({
      title,
      categoryId: Number(categoryId),
      description,
      amount: Number(amount),
    });
  };

  return (
    <Paper sx={{ borderRadius: 3, p: 3 }}>
      <Box component="form" onSubmit={handleSubmit} sx={{ display: "flex", flexDirection: "column", gap: 3 }}>
        <Typography variant="h5">Create Expense</Typography>

        <TextField label="Title" value={title} onChange={(e) => setTitle(e.target.value)} required />

        <TextField select label="Category" value={categoryId} onChange={(e) => setCategoryId(e.target.value)} required>
          <MenuItem value="1">Food</MenuItem>
          <MenuItem value="2">Bills</MenuItem>
          <MenuItem value="3">Rent</MenuItem>
          <MenuItem value="4">Fun</MenuItem>
          <MenuItem value="5">Transport</MenuItem>
        </TextField>

        <TextField
          label="Description"
          multiline
          rows={3}
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          required
        />

        <TextField label="Amount (€)" type="number" value={amount} onChange={(e) => setAmount(e.target.value)}
          slotProps={{ htmlInput: { min: 0.01, step: 0.01 } }} required />

        {createExpense.isError && (
          <Typography color="error">
            Failed to create expense. Please try again.
          </Typography>
        )}

        <Button type="submit" variant="contained" disabled={createExpense.isPending}>
          {createExpense.isPending ? "Creating..." : "Create Expense"}
        </Button>
      </Box>
    </Paper>
  );
}
