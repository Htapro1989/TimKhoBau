import React, { useState } from "react";
import { TextField, Button, Grid, Typography, Box } from "@mui/material";
import axios from "axios";

const App = () => {
    const [n, setN] = useState(0);
    const [m, setM] = useState(0);
    const [p, setP] = useState(0);
    const [matrix, setMatrix] = useState("");
    const [result, setResult] = useState(null);

    const handleSubmit = async () => {
        const matrixData = matrix.split("\n").map((row) => row.split(" ").map(Number));

        try {
            const response = await axios.post("/api/treasure/solve", {
                rows: n,
                columns: m,
                p: p,
                matrix: JSON.stringify(matrixData),
            });
            setResult(response.data.fuel);
        } catch (error) {
            console.error("Error:", error);
        }
    };

    return (
        <Box p={4}>
            <Typography variant="h4">Treasure Map Solver</Typography>
            <Grid container spacing={2}>
                <Grid item xs={4}>
                    <TextField label="Rows (n)" type="number" onChange={(e) => setN(Number(e.target.value))} fullWidth />
                </Grid>
                <Grid item xs={4}>
                    <TextField label="Columns (m)" type="number" onChange={(e) => setM(Number(e.target.value))} fullWidth />
                </Grid>
                <Grid item xs={4}>
                    <TextField label="P (Number of Keys)" type="number" onChange={(e) => setP(Number(e.target.value))} fullWidth />
                </Grid>
                <Grid item xs={12}>
                    <TextField
                        label="Matrix (Space-separated rows)"
                        multiline
                        rows={6}
                        onChange={(e) => setMatrix(e.target.value)}
                        fullWidth
                    />
                </Grid>
                <Grid item xs={12}>
                    <Button variant="contained" onClick={handleSubmit}>
                        Solve
                    </Button>
                </Grid>
                {result !== null && (
                    <Grid item xs={12}>
                        <Typography variant="h6">Minimum Fuel Required: {result.toFixed(2)}</Typography>
                    </Grid>
                )}
            </Grid>
        </Box>
    );
};

export default App;