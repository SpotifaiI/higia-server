﻿namespace HigiaServer.Domain.ValueObjects;

public record Coordinate(double Latitude, double Longitude);
public record Route(Coordinate InitialLocation, Coordinate EndLocation);

public class TaskLocation
{
    public Coordinate InitialLocation { get; }
    public Coordinate EndLocation { get; }

    public TaskLocation(Coordinate initialLocation, Coordinate endLocation)
    {
        InitialLocation = initialLocation;
        EndLocation = endLocation;
    }
}