import React, { useEffect, useState } from "react";

// Define the TypeScript interface for a Bowler
interface Bowler {
  bowlerID: number;
  bowlerFirstName: string;
  bowlerMiddleInit?: string;
  bowlerLastName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
  team: {
    teamName: string;
  };
}

const BowlerTable: React.FC = () => {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        const response = await fetch("http://localhost:5001/Bowlers");
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data: Bowler[] = await response.json();
        setBowlers(data);
      } catch (err) {
        setError("Error fetching data. Please check your API.");
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchBowlers();
  }, []);

  if (loading) return <p style={{ textAlign: "center" }}>Loading...</p>;
  if (error) return <p style={{ textAlign: "center", color: "red" }}>{error}</p>;

  return (
    <div>
      <h2 style={{ textAlign: "center" }}>Bowler List</h2>
      <table border={1} style={{ width: "80%", margin: "auto", textAlign: "left" }}>
        <thead>
          <tr>
            <th>Name</th>
            <th>Team</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler) => (
            <tr key={bowler.bowlerID}>
              <td>{`${bowler.bowlerFirstName} ${bowler.bowlerMiddleInit || ""} ${bowler.bowlerLastName}`}</td>
              <td>{bowler.team.teamName}</td>
              <td>{bowler.bowlerAddress}</td>
              <td>{bowler.bowlerCity}</td>
              <td>{bowler.bowlerState}</td>
              <td>{bowler.bowlerZip}</td>
              <td>{bowler.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BowlerTable;
