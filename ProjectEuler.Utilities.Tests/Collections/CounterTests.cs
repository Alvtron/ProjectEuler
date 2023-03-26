
using ProjectEuler.Utilities.Collections;

namespace ProjectEuler.Utilities.Tests.Collections
{
    [TestFixture]
    public class CounterTests
    {
        private const string FirstKey = "first_key";
        private const string SecondKey = "second_key";
        private const string ThirdKey = "third_key";

        private readonly IDictionary<string, int> testData = new Dictionary<string, int>()
        {
            { FirstKey, 1 },
            { SecondKey, 3 },
            { ThirdKey, 2 },
        };

        [Test]
        public void Constructor_NoParameters_CreatesEmptyCounter()
        {
            // ARRANGE & ACT
            var emptyCounter = new Counter<string>();

            // ASSERT
            Assert.That(emptyCounter, Is.Empty);
            Assert.That(emptyCounter, Is.Not.EquivalentTo(this.testData));
        }

        [Test]
        public void Constructor_WithDictionary_CreatesCounterWithData()
        {
            // ARRANGE & ACT
            var counter = new Counter<string>(this.testData);

            // ASSERT
            Assert.That(counter, Is.Not.Empty);
            Assert.That(counter, Is.EquivalentTo(this.testData));
        }

        [Test]
        public void Constructor_WithKeysAndStarterValue_CreatesCounterWithData()
        {
            // ARRANGE & ACT
            const int DEFAULT_COUNT = 1;
            var counter = new Counter<string>(this.testData.Keys, DEFAULT_COUNT);

            // ASSERT
            Assert.That(counter, Is.Not.Empty);
            Assert.That(counter.Keys, Is.EquivalentTo(this.testData.Keys));
            Assert.That(counter.All(count => count.Value == DEFAULT_COUNT), Is.True);
        }

        [Test]
        public void CountElements_WithElements_CreatesCounterWithCountedElements()
        {
            // ARRANGE
            const int NUMBER_OF_FIRSTS = 12;
            const int NUMBER_OF_SECONDS = 17;
            const int NUMBER_OF_THIRDS = 5;
            var firstElements = Enumerable.Repeat(FirstKey, NUMBER_OF_FIRSTS);
            var secondElements = Enumerable.Repeat(SecondKey, NUMBER_OF_SECONDS);
            var thirdElements = Enumerable.Repeat(ThirdKey, NUMBER_OF_THIRDS);
            var allElements = firstElements.Concat(secondElements).Concat(thirdElements);

            // ACT
            var counter = Counter.Count(allElements);

            // ASSERT
            Assert.That(counter, Is.Not.Null);
            Assert.That(counter, Is.Not.Empty);
            Assert.That(counter[FirstKey], Is.EqualTo(NUMBER_OF_FIRSTS));
            Assert.That(counter[SecondKey], Is.EqualTo(NUMBER_OF_SECONDS));
            Assert.That(counter[ThirdKey], Is.EqualTo(NUMBER_OF_THIRDS));
        }

        [Test]
        public void CountElements_WithoutElements_CreatesEmptyCounter()
        {
            // ARRANGE
            var emptyElements = Enumerable.Empty<string>();

            // ACT
            var counter = Counter.Count(emptyElements);

            // ASSERT
            Assert.That(counter, Is.Not.Null);
            Assert.That(counter, Is.Empty);
        }

        [Test]
        public void Increment_ExistingKey_IncrementsCount()
        {
            // ARRANGE
            var counter = this.CreateCounter();
            const int COUNTS = 3;

            // ACT
            counter.Increment(FirstKey, COUNTS);
            for (var i = 0; i < COUNTS; i++)
            {
                counter.Increment(SecondKey);
                counter[ThirdKey]++;
            }

            // ASSERT
            Assert.That(counter[FirstKey], Is.EqualTo(this.testData[FirstKey] + COUNTS));
            Assert.That(counter[SecondKey], Is.EqualTo(this.testData[SecondKey] + COUNTS));
            Assert.That(counter[ThirdKey], Is.EqualTo(this.testData[ThirdKey] + COUNTS));
        }

        [Test]
        public void Increment_MissingKey_IncrementsCount()
        {
            // ARRANGE
            var counter = CreateEmptyCounter();
            const int COUNTS = 4;

            // ACT
            counter.Increment(FirstKey, COUNTS);
            for (var i = 0; i < COUNTS; i++)
            {
                counter.Increment(SecondKey);
            }

            // ASSERT
            Assert.That(counter[FirstKey], Is.EqualTo(COUNTS));
            Assert.That(counter[SecondKey], Is.EqualTo(COUNTS));
            Assert.That(() => counter[ThirdKey]++, Throws.InstanceOf<KeyNotFoundException>());
        }

        [Test]
        public void Decrement_ExistingKey_IncrementsCount()
        {
            // ARRANGE
            var counter = this.CreateCounter();
            const int COUNTS = 5;

            // ACT
            counter.Decrement(FirstKey, COUNTS);
            for (var i = 0; i < COUNTS; i++)
            {
                counter.Decrement(SecondKey);
                counter[ThirdKey]--;
            }

            // ASSERT
            Assert.That(counter[FirstKey], Is.EqualTo(this.testData[FirstKey] - COUNTS));
            Assert.That(counter[SecondKey], Is.EqualTo(this.testData[SecondKey] - COUNTS));
            Assert.That(counter[ThirdKey], Is.EqualTo(this.testData[ThirdKey] - COUNTS));
        }

        [Test]
        public void Decrement_MissingKey_IncrementsCount()
        {
            // ARRANGE
            var counter = CreateEmptyCounter();
            const int COUNTS = 6;

            // ACT
            counter.Decrement(FirstKey, COUNTS);
            for (var i = 0; i < COUNTS; i++)
            {
                counter.Decrement(SecondKey);
            }

            // ASSERT
            Assert.That(counter[FirstKey], Is.EqualTo(-COUNTS));
            Assert.That(counter[SecondKey], Is.EqualTo(-COUNTS));
            Assert.That(() => counter[ThirdKey]++, Throws.InstanceOf<KeyNotFoundException>());
        }

        [Test]
        public void Reset_ByExistingKey_CountOfKeyIsReset()
        {
            // ARRANGE
            var counter = this.CreateCounter();
            const int RESET_VALUE = 3;

            // ACT
            counter.Reset(FirstKey);
            counter.Reset(SecondKey, RESET_VALUE);

            // ASSERT
            Assert.That(counter[FirstKey], Is.Zero);
            Assert.That(counter[SecondKey], Is.EqualTo(RESET_VALUE));
        }

        [Test]
        public void Reset_ByMissingKey_ThrowsError()
        {
            // ARRANGE
            var counter = CreateEmptyCounter();

            // ACT & ASSERT
            Assert.That(() => counter.Reset(FirstKey), Throws.InstanceOf<KeyNotFoundException>());
        }

        [Test]
        public void Reset_WithData_AllCountsAreReset()
        {
            // ARRANGE
            var counterA = this.CreateCounter();
            var counterB = this.CreateCounter();
            const int RESET_VALUE = 3;

            // ACT
            counterA.Reset();
            counterB.Reset(RESET_VALUE);

            // ASSERT
            Assert.That(counterA, Is.Not.Empty);
            Assert.That(counterB, Is.Not.Empty);
            Assert.That(counterA.Values, Is.All.Zero);
            Assert.That(counterB.Values, Is.All.EqualTo(RESET_VALUE));
        }

        [Test]
        public void Reset_WithoutData_NothingHappens()
        {
            // ARRANGE
            var counterA = CreateEmptyCounter();
            var counterB = CreateEmptyCounter();
            const int RESET_VALUE = 3;

            // ACT
            counterA.Reset();
            counterB.Reset(RESET_VALUE);

            // ASSERT
            Assert.That(counterA, Is.Empty);
            Assert.That(counterB, Is.Empty);
        }

        [Test]
        public void Combine_WithData_CombinesCounts()
        {
            // ARRANGE
            const string FOURTH_KEY = "fourth_key";
            const int FOURTH_VALUE = 45;
            const string FIFTH_KEY = "fifth_key";
            const int FIFTH_VALUE = 29;

            var counterA = this.CreateCounter();
            var counterACopy = new Counter<string>(counterA);
            counterA.Add(FOURTH_KEY, FOURTH_VALUE);
            counterA.Add(FIFTH_KEY, FIFTH_VALUE);

            var counterB = this.CreateCounter();
            var counterBCopy = new Counter<string>(counterB);

            // ACT
            counterB.Combine(counterA);

            // ASSERT
            Assert.That(counterA, Is.Not.Empty);
            Assert.That(counterA, Is.Not.EquivalentTo(counterACopy));
            Assert.That(counterB, Is.Not.Empty);
            Assert.That(counterB, Is.Not.EquivalentTo(counterA));
            Assert.That(counterB[FirstKey], Is.EqualTo(counterA[FirstKey] + counterBCopy[FirstKey]));
            Assert.That(counterB[SecondKey], Is.EqualTo(counterA[SecondKey] + counterBCopy[SecondKey]));
            Assert.That(counterB[ThirdKey], Is.EqualTo(counterA[ThirdKey] + counterBCopy[ThirdKey]));
            Assert.That(counterB, Contains.Key(FOURTH_KEY));
            Assert.That(counterB[FOURTH_KEY], Is.EqualTo(FOURTH_VALUE));
            Assert.That(counterB, Contains.Key(FIFTH_KEY));
            Assert.That(counterB[FIFTH_KEY], Is.EqualTo(FIFTH_VALUE));
        }

        private static Counter<string> CreateEmptyCounter()
        {
            return new Counter<string>();
        }

        private Counter<string> CreateCounter()
        {
            return new Counter<string>(this.testData);
        }
    }
}
