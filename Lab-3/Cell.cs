/* Lab Question (Test 2) 
 * 
 * Here we have used a List to hold the phonons. Given that we will need to remove phonons
 * from many different locations of the List (front, middle, back) do you think
 * this is an appropriate data structure to use? Keep in mind, we will also need repeatedly
 * iterate over the List and the List could contain many phonons. Random access is not required.
 * Justify your choice of a different data structure or explain why a List is a good choice.
 * 
 * Can you think of a clever way to remove an element from the middle of a List without having
 * to shift the memory contents of the List? 
 */
 
using System;
using System.Collections.Generic;

using Psim.Geometry2D;
using Psim.Particles;

namespace Psim.ModelComponents
{
	public enum SurfaceLocation
	{
		left = 0,
		top =1,
		right= 2,
		bot = 3
	}

	public class Cell : Rectangle
	{
		private const int NOTFANCY = 1;
		private const int NUM_SURFACES = 4;
		private List<Phonon> phonons = new List<Phonon>() {};
		private List<Phonon> incomingPhonons = new List<Phonon>() { };
		private ISurface[] surfaces = new ISurface[NUM_SURFACES];
		public List<Phonon> Phonons { get { return phonons; } }

		public Cell(double length, double width)
			: base(length, width)
		{
			// Initialize cell with 4 boumdary surfaces covering the 4 possible surface locations
			// and put them in the correct position in the surface array
#if true
			for (int i = 0; i < NUM_SURFACES; ++i)
            {
				surfaces[i] = new BoundarySurface((SurfaceLocation)i, this);
            }
#else
              foreach ( int surface  in Enum.GetValue(typeof(SurfaceLocation)))
			  {
			    surface [surface] = new Boundarysurface((SurfaceLocation)surface, this);
				}
#endif
		}

		/// <summary>
		/// Adds a phonon to the main phonon 'array' of the cell.
		/// </summary>
		/// <param name="p">The phonon that will be added</param>
		public void AddPhonon(Phonon p)
		{
			phonons.Add(p);
		}

		/// <summary>
		/// Adds a phonon to the incoming phonon 'array' of the cell
		/// The incoming phonon will come from the phonons 'array' of another cell
		/// </summary>
		/// <param name="p">The phonon that will be added</param>
		public void AddIncPhonon(Phonon p)
		{
			// This could cause a very nasty bug lasty bug later on- be sure to verify now
			incomingPhonons.Add(p);
		}

		/// <summary>
		/// Merges the incoming phonons with the existing phonons and clears the incoming phonons
		/// </summary>
		public void MergeIncPhonons()
		{
			phonons.AddRange(incomingPhonons);
			incomingPhonons.Clear();
		}

		/// <summary>
		/// Returns the surface at SurfaceLocation loc
		/// </summary>
		/// <param name="loc">The SurfaceLocation of the surface to be returned</param>
		/// <returns>The surface at location loc</returns>
		public ISurface GetSurface(SurfaceLocation loc)
		{
			return surfaces[(int)loc];
		}

		/// <summary>
		/// Moves a phonon to the surface that it will impact first.
		/// The phonon will be moved to the surface and the surface
		/// it impacts is returned
		/// </summary>
		/// <param name="p">The phonon to be moved</param>
		/// <returns>The surface that the phonon collides with</returns>
		public SurfaceLocation? MoveToNearestSurface(Phonon p)
		{
			//To test this, you will need to create a cell -> the surface will be set up automatically now
			//You need to add a phonon ->
			//TODO - challemging !! be cautious of floating point issues!
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return string.Format("{0,-7} {1,-7}", phonons.Count, incomingPhonons.Count);
		}
	}
}
