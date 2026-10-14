import { Wallet, Error } from '@mui/icons-material';
import { Box, CircularProgress, Typography } from '@mui/material';

type Props = {
    title: string;
    value: string | undefined;
    isPending: boolean;
    isError: boolean;
}

export default function ExpenseCard({ title, value, isPending, isError }: Props) {

    return (
        <Box sx={{ borderRadius: 5, backgroundColor: "background.paper",
                p: 3, border: 2, borderColor: "divider", maxWidth: '38%', width:'33%', mt: 1, px: 5 }} >
            <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                <Wallet />
                <Typography variant='h6' color="text">{title}</Typography>
            </Box>

            {isPending ? <CircularProgress aria-label="Loading…" />
                : isError ? <Error />
                    : <Typography color="text" variant='h3'>{value}</Typography>}
        </Box>
    );
}
